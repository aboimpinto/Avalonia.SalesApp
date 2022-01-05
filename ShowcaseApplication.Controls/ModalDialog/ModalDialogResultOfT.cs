namespace ShowcaseApplication.Controls
{
    public class ModalDialogResult<TResult>
    {
        public int ExitCode { get; }

        public TResult Result { get; }

        public ModalDialogResult(TResult result, int exitCode)
        {
            this.ExitCode = exitCode;
            this.Result = result;
        }
    }
}
