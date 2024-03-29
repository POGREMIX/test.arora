﻿using CJE.Http.RequestAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGuestbook.Handler
{
    public class Rating : CJE.Http.RequestHandlers.RequestHandlerBase
    {
        public Rating(CJE.Http.HttpServer server, System.Net.HttpListenerContext context, CJE.Http.RequestHandlerData data) : base(server, context, data) { }

        public override IAnswer HandlePOST()
        {
            Form.Rating inputData = new Form.Rating(Data.Post.Input);
            Data.Rating inputRating = inputData.ToData();

            Data.Rating rating = DB.RatingController.UpdateRating(Server.DBSession, inputRating);

            return new CJE.Http.RequestAnswer.Json(rating);
        }
    }
}
