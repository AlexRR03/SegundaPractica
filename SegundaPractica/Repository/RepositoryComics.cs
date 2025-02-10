using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SegundaPractica.Models;

namespace SegundaPractica.Repository
{
    public class RepositoryComics
    {
        private DataTable tablaComics;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryComics() 
        {
            string cnString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=COMICS;User ID=sa;Trust Server Certificate=True";
            string sql = "select * from COMICS";
            SqlDataAdapter adapter = new SqlDataAdapter(sql,cnString);
            this.tablaComics = new DataTable();
            adapter.Fill(this.tablaComics);
            this.cn = new SqlConnection(cnString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Comics> GetComics()
        {
            var consulta = from datos in this.tablaComics.AsEnumerable() select datos;
            List<Comics> listaComics = new List<Comics>();
            foreach (var row in consulta) { 
                Comics comic = new Comics();
                comic.Id = row.Field<int>("IDCOMIC");
                comic.Nombre = row.Field<string>("NOMBRE");
                comic.Imagen = row.Field<string>("IMAGEN");
                comic.Descripcion = row.Field<string>("DESCRIPCION");
                listaComics.Add(comic);
            }
            return listaComics;
        }
        public List<string> GetNombreComics ()
        {
            var consulta = from datos in this.tablaComics.AsEnumerable() select datos.Field<string>("NOMBRE");
            return consulta.ToList();
        }

        
        public  Comics FindComic(string nombrecomic)
        {
            var consulta = from datos in this.tablaComics.AsEnumerable() where datos.Field<string>("NOMBRE") == nombrecomic select datos;
            var row = consulta.First();
            Comics comic = new Comics();
            comic.Id = row.Field<int>("IDCOMIC");
            comic.Nombre = row.Field<string>("NOMBRE");
            comic.Imagen = row.Field<string>("IMAGEN");
            comic.Descripcion = row.Field<string>("DESCRIPCION");
            return comic;

        }

        //public InsertComic(int id, string nombre,string imagen,string descripcion)
        //{

           
        //}

       
    }
}
