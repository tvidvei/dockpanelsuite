using System.ComponentModel;

namespace Utilities
{

    /// <summary>
    /// Abstract class handling the edit history of an editable object
    /// </summary>
    /// <typeparam name="I">Type of items with the editable object that are changed by an edit operation</typeparam>
    /// <typeparam name="V">Value type</typeparam>
    public abstract class EditHistoryManager<I,V>
    {

        /// <summary>
        /// Class representing a single edit operation
        /// </summary>
        protected class Edit
        {
            /// <summary>
            /// Item within a document that are changed
            /// </summary>
            public I Item { get; set; }

            /// <summary>
            /// Old value
            /// </summary>
            public V? OldValue { get; set; }

            /// <summary>
            /// New Value
            /// </summary>
            public V? NewValue { get; set; }

            public Edit(I item, V? oldValue, V? newValue) {
                Item = item;
                OldValue = oldValue;
                NewValue = newValue;
            }
        }

        /// <summary>
        /// List of Edits
        /// </summary>
        protected List<Edit> Edits = new List<Edit>();

        /// <summary>
        /// Position of next  or newly inserted Edit
        /// </summary>
        public int CurrentPos { get; protected set; } = 0;

        /// <summary>
        /// Edit at CurrentPos if newly inserted, else null
        /// </summary>
        protected Edit? CurrentEdit => CurrentPos < Edits.Count ? Edits[CurrentPos] : null;

        /// <summary>
        /// Position of last edit
        /// </summary>
        protected int LastPos => CurrentPos - 1;

        /// <summary>
        /// CurrentPosition when saved. Zero by default as no save has taken place
        /// </summary>
        protected int SavedPos { get; set; } = 0;

        /// <summary>
        /// Last edit
        /// </summary>
        protected Edit? LastEdit => LastPos < 0 ? null : Edits[LastPos];

        public bool IsChanged => CurrentPos != SavedPos;

        /// <summary>
        /// Register a new Edit to the history
        /// </summary>
        /// <param name="item">Item to be changed</param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        /// <param name="setValue">if true: Perform the edit</param>
        /// <returns>True if success. False if newValue equals oldValue</returns>
        public bool AddEdit(I item, V? oldValue, V? newValue, bool setValue = false)
        {
            if (AreEqualValues(item, newValue, oldValue)) return false;
            if (CurrentPos < Edits.Count)
            {
                Edits.RemoveRange(CurrentPos, Edits.Count - CurrentPos);
            }
            Edits.Add(new Edit(item, oldValue, newValue));
            if (CurrentPos < SavedPos) SavedPos = 0;
            CurrentPos++;
            if (setValue) SetValue(CurrentEdit!.Item, CurrentEdit!.NewValue);
            return true;
        }

        /// <summary>
        /// Undo last edit
        /// </summary>
        /// <returns>True if success. False if no edit to undo</returns>
        public bool UndoEdit() {
            if (CurrentPos == 0) return false;
            CurrentPos--;
            SetValue(CurrentEdit!.Item, CurrentEdit!.OldValue);
            return true;
        }

        /// <summary>
        /// Redo last undone edit
        /// </summary>
        /// <returns>True if success. False if no previously undone edit to redo</returns>
        public bool RedoEdit()
        {
            if (CurrentPos >= Edits.Count) return false;
            SetValue(CurrentEdit!.Item, CurrentEdit!.NewValue);
            CurrentPos++;
            return true;
        }


        /// <summary>
        /// Clears the EditHistory
        /// </summary>
        /// Removes all edits from the history and sets CurrentPos to 0
        public void Clear() { 
            Edits.Clear();
            CurrentPos = 0;
            SavedPos = 0;
        }  


        /// <summary>
        /// Called when the object under edit is saved. Sets SavedPos to CurrentPos
        /// </summary>
        public void SaveCurrentPos()
        {
            SavedPos = CurrentPos;
        }

        /// <summary>
        /// Returns true if value1 is equal to value2
        /// </summary>
        /// <param name="value1">value 1 to be compared</param>
        /// <param name="value2">value 2 to be compared</param>
        /// <returns></returns>
        public abstract bool AreEqualValues(I item, V? value1, V? value2);


        /// <summary>
        /// Set the the value of item to value
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract void SetValue(I item, V? value);


        /// <summary>
        /// Default constructor
        /// </summary>
        public EditHistoryManager() {  }

    }

}
