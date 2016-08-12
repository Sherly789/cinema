using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System;
namespace Cinema
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Movie> AllMovies = Movie.GetAll();
        return View["index.cshtml", AllMovies];
      };

      Get["/admin"] = _ => {
        return View["admin.cshtml"];
      };

      Get["/movies"] = _ => {
        List<Movie> AllMovies = Movie.GetAll();
        return View["movies.cshtml", AllMovies];
      };

      Get["/theaters"] = _ => {
        List<Theater> AllTheaters = Theater.GetAll();
        return View["theaters.cshtml", AllTheaters];
      };

      Get["/theaters/new"] = _ => {
        List<Theater> AllTheaters = Theater.GetAll();
        return View["theater_form.cshtml", AllTheaters];
      };

      Post["/theaters/new"] = _ => {
        Theater newTheater = new Theater(Request.Form["theater-location"], Request.Form["theater-date"]);
        newTheater.Save();
        return View["admin.cshtml"];
      };

      Get["/movies/new"] = _ => {
        List<Movie> allMovies = Movie.GetAll();
        return View["movies_form.cshtml", allMovies];
      };

      Post["/movies/new"] = _ => {
        Movie newMovie = new Movie(Request.Form["movie-title"], Request.Form["movie-rating"]);
        newMovie.Save();
        return View["admin.cshtml"];
      };

      Get["movies/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Movie SelectedMovie = Movie.Find(parameters.id);
          List<Theater> MovieTheaters = SelectedMovie.GetTheaters();
          List<Theater> AllTheaters = Theater.GetAll();
          model.Add("movie", SelectedMovie);
          model.Add("movieTheaters", MovieTheaters);
          model.Add("allTheaters", AllTheaters);
          return View["movie.cshtml", model];
        };

        Get["movie_to_theater/{id}"] = parameters => {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Movie SelectedMovie = Movie.Find(parameters.id);
            List<Theater> MovieTheaters = SelectedMovie.GetTheaters();
            List<Theater> AllTheaters = Theater.GetAll();
            model.Add("movie", SelectedMovie);
            model.Add("movieTheaters", MovieTheaters);
            model.Add("allTheaters", AllTheaters);
            return View["movie_to_theater.cshtml", model];
          };

        Get["theaters/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Theater SelectedTheater = Theater.Find(parameters.id);
          List<Movie> TheaterMovies = SelectedTheater.GetMovies();
          List<Movie> AllMovies = Movie.GetAll();
          model.Add("theater", SelectedTheater);
          model.Add("theaterMovies", TheaterMovies);
          model.Add("allMovies", AllMovies);
          return View["theater.cshtml", model];
        };

        Get["/theater-add/{id}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Theater SelectedTheater = Theater.Find(parameters.id);
          List<Movie> TheaterMovies = SelectedTheater.GetMovies();
          List<Movie> AllMovies = Movie.GetAll();
          model.Add("theater", SelectedTheater);
          model.Add("theaterMovies", TheaterMovies);
          model.Add("allMovies", AllMovies);
          return View["theater_assign.cshtml", model];
        };

        Post["movie/add_theater"] = _ => {
          Theater theater = Theater.Find(Request.Form["theater-id"]);
          Movie movie = Movie.Find(Request.Form["movie-id"]);
          movie.AddTheater(theater);
          return View["admin.cshtml"];
        };

        Post["theater/add_movie"] = _ => {
          Theater theater = Theater.Find(Request.Form["theater-id"]);
          Movie movie = Movie.Find(Request.Form["movie-id"]);
          theater.AddMovies(movie);
          return View["admin.cshtml"];
        };

        Post["/movies/delete"] = _ => {
          Movie.DeleteAll();
          return View["cleared.cshtml"];
        };

        Get["theater/edit/{id}"] = parameters => {
          Theater SelectedTheater = Theater.Find(parameters.id);
          return View["theater_edit.cshtml", SelectedTheater];
        };

        Patch["theater/edit/{id}"] = parameters => {
          Theater SelectedTheater = Theater.Find(parameters.id);
          SelectedTheater.Update(Request.Form["theater-location"], Request.Form["theater-date"]);
          return View["admin.cshtml"];
        };

        Get["/theater/delete/{id}"] = parameters => {
          Theater SelectedTheater = Theater.Find(parameters.id);
          return View["theater_delete.cshtml", SelectedTheater];
        };

        Delete["/theater/delete/{id}"] = parameters => {
          Theater SelectedTheater = Theater.Find(parameters.id);
          SelectedTheater.Delete();
          return View["admin.cshtml"];
        };

        Post["/theaters/delete"] = _ => {
          Theater.DeleteAll();
          return View["cleared.cshtml"];
        };

        Get["movie/edit/{id}"] = parameters => {
          Movie SelectedMovie = Movie.Find(parameters.id);
          return View["movie_edit.cshtml", SelectedMovie];
        };

        Patch["movie/edit/{id}"] = parameters => {
          Movie SelectedMovie = Movie.Find(parameters.id);
          SelectedMovie.Update(Request.Form["movie-title"], Request.Form["movie-rating"]);
          return View["admin.cshtml"];
        };

        Get["/movie/delete/{id}"] = parameters => {
          Movie SelectedMovie = Movie.Find(parameters.id);
          return View["movie_delete.cshtml", SelectedMovie];
        };

        Delete["/movie/delete/{id}"] = parameters => {
          Movie SelectedMovie = Movie.Find(parameters.id);
          SelectedMovie.Delete();
          return View["admin.cshtml"];
        };

        Get["/customers/new"] = _ => {
          return View["customer_form.cshtml"];
        };

        Post["/customers/new"] = _ => {
          User newUser = new User(Request.Form["customer-name"]);
          newUser.Save();
          return View["customer_information.cshtml", newUser];
        };

        Get["/customer/select/user/{id}"] = parameters => {
          User SelectedUser = User.Find(parameters.id);
          List<Movie> AllMovies = Movie.GetAll();
          Dictionary<string, object> model = new Dictionary<string, object>();
          model.Add("allmovie", AllMovies);
          model.Add("users", SelectedUser);

          return View["customer_select.cshtml", model];
        };

        Get["/customer/select/user/{UserId}/{id}"] = parameters => {
            Dictionary<string, object> model = new Dictionary<string, object>();
            User SelectedUser = User.Find(parameters.UserId);
            Movie SelectedMovie = Movie.Find(parameters.id);
            List<Theater> MovieTheaters = SelectedMovie.GetTheaters();
            List<Theater> AllTheaters = Theater.GetAll();
            model.Add("movie", SelectedMovie);
            model.Add("user", SelectedUser);
            model.Add("movieTheaters", MovieTheaters);
            model.Add("allTheaters", AllTheaters);
            return View["customer_choice.cshtml", model];
          };

        Get["/customer/select/user/{UserId}/{id}/{TheaterId}"] = parameters => {
          Dictionary<string, object> model = new Dictionary<string, object>();
          User SelectedUser = User.Find(parameters.UserId);
          Movie SelectedMovie = Movie.Find(parameters.id);
          Theater SelectedTheater = Theater.Find(parameters.TheaterId);
          model.Add("user", SelectedUser);
          model.Add("selectedMovie", SelectedMovie);
          model.Add("selectTheater", SelectedTheater);
          return View["customer_order.cshtml",model];
        };

        Post["/customer/placeOrder"] = _ =>{
          Movie SelectedMovie = Movie.Find(Request.Form["movie-order-id"]);
          Theater SelectedTheater = Theater.Find(Request.Form["theater-order-id"]);
          Console.WriteLine("MovieId"+SelectedMovie.GetId());
          Console.WriteLine("SelectedTheater"+SelectedTheater.GetId());

          int oneShowingId=Showing.CollectId(SelectedMovie,SelectedTheater);
          Console.WriteLine("oneShowingId"+oneShowingId);

          Order myOrder= new Order(oneShowingId,Request.Form["user-order-id"],Request.Form["order-qt"]);
          myOrder.Save();
          return View["customer_purchase.cshtml"];

        };

        Get["/customer/purchase"] = _ => {
          return View["customer_purchase.cshtml"];
        };
    }
  }
}
