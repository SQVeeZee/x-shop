namespace Shop
{
    public class DescriptionHandler
    {
        public void UpdateDescription(DescriptionData descriptionData)
        {
            var description = descriptionData.ProductConfig.GetDescription();
            descriptionData.CurrencyDescription.SetDescription(description);
        }
    }
}