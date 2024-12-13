using PersonalBudgetNabiullin.DatabaseContext;
using PersonalBudgetNabiullin.Entities;

namespace PersonalBudgetNabiullin;

public partial class AddTransactionPage : ContentPage
{
	public AddTransactionPage()
	{
		InitializeComponent();
	}

    private void AddTransaction(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
		string description =DescriptionEntry.Text;
		string amount =AmountEntry.Text;

		bool isTitleEmpty = string.IsNullOrEmpty(title);
		if (isTitleEmpty) 
		{
			AppShell.Current.DisplayAlert("������", "��������� �� ����� ���� ������!","��");
			return;
		}
		
		bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
		if (isDescriptionEmpty) 
		{
			AppShell.Current.DisplayAlert("������","�������� ����� �� ����� ���� ������!","��");
			return;
		}

        bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
        if (isAmountEmpty)
        {
            AppShell.Current.DisplayAlert("������", "���-�� ����� �� ����� ���� ������!", "��");
            return;
        }

		decimal amountConvertedToDecimal = Convert.ToDecimal(amount);

		ApplicationDbContext dbContext = new ApplicationDbContext();
		dbContext.Transactions.Add(new TransactionEntity(title, description, amountConvertedToDecimal));
		dbContext.SaveChanges();

		AppShell.Current.DisplayAlert("�����", "������� ������� ���������", "��");
		AppShell.Current.GoToAsync("..", true);

    }
}