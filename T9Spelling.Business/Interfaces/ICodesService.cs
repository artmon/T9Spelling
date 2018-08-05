using JetBrains.Annotations;

namespace T9Spelling.Business.Interfaces
{
    public interface ICodesService
    {
        /// <summary>
        /// Return digit string code for input string
        /// </summary>
        /// <param name="s">input string, can consist of only lowercase characters a-z and space characters </param>
        /// <returns>digit string code</returns>
        [NotNull]
        string GetStringCode([NotNull] string s);
    }
}