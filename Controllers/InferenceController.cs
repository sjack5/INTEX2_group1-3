using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using ONNX4INTEX.Models;
using Microsoft.ML.OnnxRuntime.Tensors;


namespace aspnetcore.Controllers
{
    [ApiController]
    [Route("/predict")]
    public class InferenceController : ControllerBase
    {
        private InferenceSession _session;
        public InferenceController(InferenceSession session)
        {
            _session = session;
        }
        [HttpPost]
        public ActionResult Score(SupervisedModel data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First() };
            result.Dispose();
            return Ok(prediction);
        }
    }
}