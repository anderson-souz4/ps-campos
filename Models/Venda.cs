namespace ps.Models
{
    public class Venda
    {
        
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int QtdVenda { get; set; }
        public float VlrUnitarioVenda{ get; set; }
        public DateTime DthVenda { get; set; }


        public float VlrTotalVenda  
        {
            get
            {
                return QtdVenda * VlrUnitarioVenda;
            }
        }



    }
}
