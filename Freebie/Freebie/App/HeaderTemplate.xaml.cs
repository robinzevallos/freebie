using Haka.Templates;
using System;

namespace Freebie
{
    public partial class HeaderTemplate : BaseHeaderTemplate
    {
        public HeaderTemplate()
        {
            InitializeComponent();

            backTemplate.Tap = Back;
        }

        public override void SetTitle(String title)
        {
            titleLabel.Text = title;
        }
    }
}