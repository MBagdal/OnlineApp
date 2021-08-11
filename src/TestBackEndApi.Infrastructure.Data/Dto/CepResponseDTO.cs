using System;
using System.Collections.Generic;
using System.Text;

namespace TestBackEndApi.Infrastructure.Data.Dto
{
	public class CepResponseDTO
	{
		public string Cep { get; set; }

		public string Logradouro { get; set; }

		public string Complemento { get; set; }

		public string Bairro { get; set; }

		public string Localidade { get; set; }

		public List<MensagemQueryResponseDTO> Mensagens { get; set; }
	}

	public class MensagemQueryResponseDTO
	{
		public string Mensagem { get; set; }
	}
}
