namespace Logger.Appenders
{
    using Logger.Layouts;
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string message);
    }
}
