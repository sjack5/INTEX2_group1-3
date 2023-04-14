using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONNX4INTEX.Models
{
    
    public class SupervisedModel
    {
        public float Head_Direction_West { get; set; }
        public float Sample_Collected_True { get; set;}
        public float Face_Bundles_Y { get; set; }
        public float Adult_Sub_Adult_C { get; set; }
        public float Head_Direction_E { get; set; }
        public float Sample_Collected_False { get; set; }
        public float Face_Bundles { get; set; }
        public float Adult_Sub_Adult_A { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                Head_Direction_West, Sample_Collected_True, Face_Bundles_Y, Adult_Sub_Adult_C, Sample_Collected_False, Head_Direction_E, Face_Bundles, Adult_Sub_Adult_A
            };
            int[] dimensions = new int[] { 1, 8 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
