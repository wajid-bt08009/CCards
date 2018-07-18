using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CCards.Models;

namespace CCards.Controllers
{
    public class CardDetailController : ApiController
    {
        private CCardsEntities db = new CCardsEntities();

        // GET api/CardDetail
        public IQueryable<CardDetail> GetCardDetails()
        {
            return db.CardDetails;
        }



        // GET api/CardDetail/5
        [ResponseType(typeof(ValidateResult))]
        public async Task<IHttpActionResult> GetCardDetail(string id)
        {
            CardDetail carddetail = await db.CardDetails.FindAsync(id);

            ValidateResult vdResult = new ValidateResult();

            vdResult.CardType = Utilities.Card_UnKnown;
            vdResult.Result = Utilities.Result_NotFound;

            if (carddetail != null)
            {
                if (carddetail.CardNo != null && carddetail.CardNo != "" && carddetail.Expiry != null && carddetail.Expiry != "")
                {
                    int month = Convert.ToInt32(carddetail.Expiry.Substring(0, 2));
                    int year = Convert.ToInt32(carddetail.Expiry.Substring(2, 4));

                    if ((month >= DateTime.Now.Month && year >= DateTime.Now.Year) || ((month < DateTime.Now.Month && year > DateTime.Now.Year)))
                    {
                        if (carddetail.CardNo.Length >= 15)
                        {
                            if (carddetail.CardNo.Length == 15 && carddetail.CardNo[0] == '3')
                            {
                                vdResult.CardType = Utilities.Card_Amex;
                                vdResult.Result = Utilities.Result_Valid;

                                return Ok(vdResult);
                            }
                            else if (carddetail.CardNo.Length > 15)
                            {
                                if (carddetail.CardNo[0] == '4' && year % 4 == 0)
                                {
                                    vdResult.CardType = Utilities.Card_Visa;
                                    vdResult.Result = Utilities.Result_Valid;

                                    return Ok(vdResult);
                                }
                                else if (carddetail.CardNo[0] == '5' && Utilities.IsPrime(year) != 0)
                                {
                                    vdResult.CardType = Utilities.Card_MasterCard;
                                    vdResult.Result = Utilities.Result_Valid;

                                    return Ok(vdResult);
                                }
                                else if (carddetail.CardNo[0] == '3')
                                {
                                    vdResult.CardType = Utilities.Card_JCB; 
                                    vdResult.Result = Utilities.Result_Valid;

                                    return Ok(vdResult);
                                }
                            }
                        }
                    }
                }

                vdResult.CardType = Utilities.Card_UnKnown;
                vdResult.Result = Utilities.Result_Invalid;
            }

            return Ok(vdResult);
        }


        // PUT api/CardDetail/5
        public async Task<IHttpActionResult> PutCardDetail(string id, CardDetail carddetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carddetail.CardNo)
            {
                return BadRequest();
            }

            db.Entry(carddetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/CardDetail
        [ResponseType(typeof(CardDetail))]
        public async Task<IHttpActionResult> PostCardDetail(CardDetail carddetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CardDetails.Add(carddetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CardDetailExists(carddetail.CardNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = carddetail.CardNo }, carddetail);
        }

        // DELETE api/CardDetail/5
        [ResponseType(typeof(CardDetail))]
        public async Task<IHttpActionResult> DeleteCardDetail(string id)
        {
            CardDetail carddetail = await db.CardDetails.FindAsync(id);
            if (carddetail == null)
            {
                return NotFound();
            }

            db.CardDetails.Remove(carddetail);
            await db.SaveChangesAsync();

            return Ok(carddetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardDetailExists(string id)
        {
            return db.CardDetails.Count(e => e.CardNo == id) > 0;
        }
    }
}