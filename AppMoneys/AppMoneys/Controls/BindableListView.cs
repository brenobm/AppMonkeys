using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMoneys.Controls
{
    public class BindableListView: ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand",
                typeof(ICommand),
                typeof(BindableListView),
                null);

        public ICommand ItemTappedCommand
        {
            get
            {
                return (ICommand)GetValue(ItemTappedCommandProperty);
            }
            set
            {
                SetValue(ItemTappedCommandProperty, value);
            }
        }

        public BindableListView(ListViewCachingStrategy strategy) : base(strategy)
        {
            Initialize();
        }

        public BindableListView() : this(ListViewCachingStrategy.RecycleElement)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.ItemSelected += (sender, e) =>
            {
                if (ItemTappedCommand == null)
                    return;

                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                    ItemTappedCommand.Execute(e.SelectedItem);
            };
        }
    }
}
