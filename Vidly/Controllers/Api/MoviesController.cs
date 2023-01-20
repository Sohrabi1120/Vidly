using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Core;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public readonly IUnitOfWork _unitOfWork;
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public IEnumerable< MovieDto> GetMovies()
        {
            return _unitOfWork.Movies.GetAll().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _unitOfWork.Movies.Get(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            var movie = Mapper.Map<MovieDto,Movie>(movieDto);
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            var movieInDb = _unitOfWork.Movies.Get(id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieInDb);
            _unitOfWork.Complete();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _unitOfWork.Movies.Get(id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _unitOfWork.Movies.Remove(movieInDb);
            _unitOfWork.Complete();
        }
    }
}
