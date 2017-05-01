using AppMoneys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMoneys.ViewModels
{
    public class ContentWebViewModel: BaseViewModel
    {
        public Content Content { get; }

        public ContentWebViewModel(Content content)
        {
            Content = content;
        }
    }
}
