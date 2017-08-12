using spots.Models.Email.Templates.Default;

namespace spots.Models.Email.Templates
{
    public interface ITemplate
    {
        IDefaultTemplate Default { get; set; }
    }
}
