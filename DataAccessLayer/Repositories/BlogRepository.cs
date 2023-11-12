using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class BlogRepository : IBlogDal
    {
        Context b = new Context();
        public void AddBlog(Blog blog)
        {
            b.Add(blog);
            b.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            b.Remove(blog);
            b.SaveChanges();
        }

        public Blog GetById(int id)
        {
            return b.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            return b.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            b.Update(blog);
            b.SaveChanges();
        }
    }
}
