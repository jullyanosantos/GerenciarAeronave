using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarAeronave.Api.Controllers
{
    [Route("api/aeronave")]
    public class AeronaveController : Controller
    {
        #region Attributes
        private readonly IAeronaveApplication _aeronaveApplication;

        #endregion

        #region Constructors
        public AeronaveController(IAeronaveApplication aeronaveApplication)
        {
            _aeronaveApplication = aeronaveApplication;
        }
        #endregion

        #region Public Methods
        public BaseResult Get([FromBody] AeronaveViewModel aeronave)
        {
            try
            {
                var aeronaves = _aeronaveApplication.GetAll(aeronave);

                if (aeronaves.Any())
                {
                    var result = new BaseResult
                    {
                        Success = true,
                        Object = aeronaves
                    };

                    return result;
                }

                var msg = "Não existem dados com essa pesquisa.";

                return new BaseResult
                {
                    Message = msg
                };
            }
            catch (Exception ex)
            {
                return new BaseResult
                {
                    Message = "Error, tente novamente."
                };
            }
        }
        #endregion

        [Route("list-all")]
        [HttpGet]
        public IEnumerable<AeronaveViewModel> Get()
        {
            var result = _aeronaveApplication.GetAll();

            return result;
        }

        [HttpGet("get-aeronave/{id}")]
        public AeronaveViewModel Get(int id)
        {
            var aeronave = _aeronaveApplication.GetAll(new AeronaveViewModel { Id = id });

            return aeronave.FirstOrDefault();
        }

        [HttpPost("save-aeronave/")]
        public int Post([FromBody]AeronaveViewModel aeronave)
        {
            return _aeronaveApplication.Add(aeronave);
        }

        [HttpPut("update-aeronave/")]
        public int Put([FromBody]AeronaveViewModel aeronave)
        {
            return _aeronaveApplication.Update(aeronave);
        }

        [HttpDelete("delete-aeronave/{id}")]
        public int Delete(int id)
        {
            return _aeronaveApplication.Delete(id);
        }
    }
}