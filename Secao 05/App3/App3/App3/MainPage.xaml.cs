using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3.Service.Model;
using App3.Service;

namespace App3
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

            
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            //todo logica do programa

            //todo validacoes
            string cep = CEP.Text.Trim();

            if (isValidCep(cep))
            {

                try
                {
                    Endereco end = ViaCepService.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0}, {1} {2} {3}  ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço não foi encontrado para o CEP informado" + cep, "OK");
                    }
                   

                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
            }
           
            
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {

                DisplayAlert("Erro", "CEP invalido! o cep deve conter 8 caracteres", "OK" );
                valido = false;
                //erro
            }
            int NovoCep = 0;

            if(!int.TryParse(cep, out NovoCep))
            {

                DisplayAlert("Erro", "CEP invalido! o cep deve ser composto por numeros", "OK");
                valido = false;
                //erro
            }
            return valido;
        }

    }
}
