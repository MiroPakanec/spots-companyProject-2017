using spots.Models.Email.Templates.Default;

namespace spots.Models.Email.Templates
{
    public class Template : ITemplate
    {
        public Template()
        {
            Default = new DefaultTemplate();
        }

        public IDefaultTemplate Default { get; set; }
    }
}