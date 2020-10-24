using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace OrderProcessor
{
    public class StepFunctionTasks
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public StepFunctionTasks()
        {
        }


        public State ProcessOrder(State state, ILambdaContext context)
        {
            state.Message = "OrderProcessing Started";

            if(!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }

            // Tell Step Function to wait 5 seconds before calling 
            state.WaitInSeconds = 5;
            state.Message = "OrderProcessing Completed";
            Console.Write("OrderProcessing Completed Successfully");
            return state;
        }

        public State ProcessPayment(State state, ILambdaContext context)
        {
            state.Message = "PaymentProcessing Started";

            if (!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }

            // Tell Step Function to wait 5 seconds before calling 
            state.WaitInSeconds = 5;

            state.Message = "PaymentProcessing Completed";
            Console.Write("PaymentProcessing Completed Successfully");

            return state;
        }

        public State ProcessEmail(State state, ILambdaContext context)
        {
            state.Message = "EmailProcessing Started";

            if (!string.IsNullOrEmpty(state.Name))
            {
                state.Message += " " + state.Name;
            }


            Console.Write("EmailProcessing Completed Successfully");

            return state;
        }
    }
}
