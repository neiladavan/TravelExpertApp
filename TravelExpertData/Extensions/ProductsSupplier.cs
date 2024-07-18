namespace TravelExpertData;

public partial class ProductsSupplier
{

    public override string ToString()
    {
        if (Product != null && Supplier != null) // Check if related entities are loaded
        {
            string productName = Product.ProdName;
            string supplierName = Supplier.SupName;

            return $"{productName} - {supplierName}";
        }
        else
        {
            return "Not Found"; // Fallback if entities are not loaded
        }
    }
}
