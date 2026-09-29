namespace Ciber.Xrm.Ci.TeamFoundation
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;
    using Microsoft.Xrm.Client.Windows.Controls.ConnectionDialog;

    public class XrmConnectionEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider == null || (IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService)) == null)
            {
                return value;
            }

            var connectionDialog = new ConnectionDialog();
            if (value != null)
            {
                connectionDialog.ConnectionString = value.ToString();
            }

            var nullable = connectionDialog.ShowDialog();
            if (nullable.HasValue && nullable.Value)
            {
                value = connectionDialog.ConnectionString;
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }
}
