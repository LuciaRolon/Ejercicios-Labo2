using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
  public class Local:Llamada
  {
    protected float costo;

    public override float CostoLlamada
    {
      get
      {
        return CalcularCosto();
      }
    }

    public Local(string origen, float duracion, string destino, float costo)
      :base(duracion, destino, origen)
    {
      this.costo = costo;
    }

    public Local(Llamada llamada, float costo)
      : this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
    {

    }

    protected override string Mostrar()
    {
      StringBuilder str = new StringBuilder();
      string datosLlamada = base.Mostrar();
      str.AppendFormat("{0}, Costo de Llamada: {1}", datosLlamada, this.CostoLlamada);
      return str.ToString();      
    }

    private float CalcularCosto()
    {
      return this.duracion * this.costo;
    }

    public override bool Equals(object obj)
    {
      if(obj is Local)
      {
        return true;
      }
      return false;
    }

    public override string ToString()
    {
      return this.Mostrar();
    }
  }
}
