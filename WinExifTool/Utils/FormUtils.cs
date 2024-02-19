using System.Data;

namespace WinExifTool.Utils
{
    public static class FormUtils
    {
        public static T getRow<T>(object dataBoundItem) where T : DataRow
        {
            return (T)((DataRowView)dataBoundItem).Row;
        }
    }
}
