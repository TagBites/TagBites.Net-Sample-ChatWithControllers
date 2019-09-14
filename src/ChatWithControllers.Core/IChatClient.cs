namespace ChatWithControllers
{
    public interface IChatClient
    {
        void MessageReceive(string userName, string message);
    }
}