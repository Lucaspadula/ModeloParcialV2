using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TwitterCloneApi.Data.Dtos;
using TwitterCloneApi.Models;
using TwitterCloneApi.Services;

namespace TwitterCloneApi.Controllers
{
    [ApiController]
    [Route("api/Tweets")]
    public class TweetsController : ControllerBase
    {
        private readonly ItweetsServices _tweetsServices;
        public TweetsController(ItweetsServices tweetsServices)
        {
            _tweetsServices = tweetsServices;
        }


        // GET: TweetsController
        [HttpGet]
        public async Task<IActionResult> ObtenerTweets(string? user, string? country)
        {
            return Ok( await _tweetsServices.ObtenerTodosAlgunosTweets(user, country));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTweet(int id, [FromBody] ActualizarTweetsDtos actualizarTweets) {

            return Ok( await _tweetsServices.ActualizarTweet(id, actualizarTweets));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {

            return Ok(await _tweetsServices.BorrarTweet(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTweetsDtos createTweetsDtos) {
            return Ok(await _tweetsServices.CrearTweet(createTweetsDtos));
        }

        //// GET: TweetsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TweetsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TweetsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TweetsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TweetsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TweetsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TweetsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
