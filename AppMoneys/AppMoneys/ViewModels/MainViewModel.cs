namespace AppMoneys.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private string _propriedadeTexto = "Texto Inicial";

        public string PropriedadeTexto
        {
            get { return _propriedadeTexto; }
            set
            {
                _propriedadeTexto = value;
                OnPropertyChanged();
            }
        }

    }
}
