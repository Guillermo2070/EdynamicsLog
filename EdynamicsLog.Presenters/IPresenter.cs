namespace EdynamicsLog.Presenters
{
    public interface IPresenter<FormatDataType>
    {
        FormatDataType Content { get; }
    }
}
