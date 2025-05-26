namespace WeifenLuo.Docking
{
    internal interface IFocusManager
    {
        void SuspendFocusTracking();
        void ResumeFocusTracking();
        bool IsFocusTrackingSuspended { get; }
        IDockContent ActiveContent { get; }
        DockPane ActivePane { get; }
        IDockContent ActiveDocument { get; }
        DockPane ActiveDocumentPane { get; }
    }

}
