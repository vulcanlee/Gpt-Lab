namespace GptService.Converts
{
    public interface IFileToText
    {
        Task<string> ToTextAsync(string filename);
    }
}