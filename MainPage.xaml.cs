using PersonalBudgetNabiullin.DatabaseContext;

namespace PersonalBudgetNabiullin
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            RefreshCollectionView();
        }

        private void GoToAddTransactionPage(object sender, EventArgs e)
        {
            AppShell.Current.GoToAsync(nameof(AddTransactionPage),true);
        }
        private void RefreshData(object sender, EventArgs e) 
        {
            RefreshCollectionView();
            RefreshV.IsRefreshing = false;
        }
        private void RefreshCollectionView() 
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            TransactionCL.ItemsSource = dbContext.Transactions.ToList();
        }
    }

}
