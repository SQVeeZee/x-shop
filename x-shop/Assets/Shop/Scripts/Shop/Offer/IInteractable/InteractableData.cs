namespace Shop
{
    public readonly struct InteractableData
    {
        public ProductConfig ProductConfig { get; }
        public IInteractable Interactable { get; }

        public InteractableData(ProductConfig productConfig, IInteractable interactableData)
        {
            ProductConfig = productConfig;
            Interactable = interactableData;
        }
    }
}