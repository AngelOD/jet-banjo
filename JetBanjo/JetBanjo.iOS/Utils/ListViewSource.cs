using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace JetBanjo.iOS.Utils
{
    public class ListViewSource<T> : UITableViewSource
    {

        List<T> items;
        string cellId = "TableCell";
        Action<bool, T> callback;

        public ListViewSource(List<T> items, Action<bool,T> callback)
        {
            this.items = items;
            this.callback = callback;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellId);
            string item = items[indexPath.Row].ToString();
            if(cell == null){
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
            }
            cell.TextLabel.Text = item;

            return cell;

        }

	public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            callback(true, items[indexPath.Row]);
	}

	public override nint RowsInSection(UITableView tableview, nint section)
        {
            return items.Count;
        }
    }
}
