using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
  public class Provincial:Llamada
  {
    public enum Franja
    {
      Franja_1,
      Franja_2,
      Franja_3
    }
    protected Franja franjaHoraria;

    public override float CostoLlamada
    {
      get
      {
        return CalcularCosto();
      }
    }

    public Provincial(string origen, Franja miFranja, float duracion, string destino)
      : base(duracion, destino, origen)
    {
      this.franjaHoraria = miFranja;
    }

    public Provincial(Franja miFranja, Llamada llamada)
      : this(llamada.NroOrigen, miFranja, llamada.Duracion, llamada.NroDestino)
    {

    }

    protected override string Mostrar()
    {
      StringBuilder str = new StringBuilder();
      string datosLlamada = base.Mostrar();
      str.AppendFormat("{0}, Costo de Llamada: {1}, Franja Horaria: {2}", datosLlamada, this.CostoLlamada, this.franjaHoraria);
      return str.ToString();
    }

    private float CalcularCosto()
    {
      float costo;
      switch (this.franjaHoraria)
      {
        case Franja.Franja_1:
          costo = 0.99f;
          break;
        case Franja.Franja_2:
          costo = 1.25f;
          break;
        case Franja.Franja_3:
          costo = 0.66f;
          break;
        default:
          costo = 0f;
          break;
      }
      return this.duracion * costo;
    }

    public override bool Equals(object obj)
    {
      if(obj is Provincial)
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
