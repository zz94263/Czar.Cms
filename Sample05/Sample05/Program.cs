using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace Sample05
{
    class Program
    {
        public static string connatr = "server=127.0.0.1;User id=root;password=123;port=3306;Database=Sample05";

        static void Main(string[] args)
        {
            //test_select_content_with_comment();
            //test_insert();
            //test_mult_insert();
            test_del();
            Console.ReadKey();
        }

        /// <summary>
        /// 测试插入单挑数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容"
            };

            var connection =new MySqlConnection(connatr);

            connection.Open();

            //using(IDbConnection conn=Dapper)

            string sql_insert = "INSERT INTO Content (title,content,status,add_time,modify_time) VALUES (@title,@content,@status,@add_time,@modify_time)";

            var result = connection.Execute(sql_insert, content);

            Console.WriteLine($"test_insert:插入了{result}条数据！");
        }
        /// <summary>
        /// 测试插入多条数据
        /// </summary>
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            },
               new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            }
        };

            var connection = new MySqlConnection(connatr);

            connection.Open();

            string sql_insert = "Insert into Content (title,content,status,add_time,modify_time) values (@title,@content,@status,@add_time,@modify_time)";

            var result = connection.Execute(sql_insert, contents);

            Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static void test_del()
        {
            var content = new Content
            {
                id = 3,
            };

            var connection = new MySqlConnection(connatr);

            connection.Open();

            string sql_insert = "Delete from content where id=@id";

            var result = connection.Execute(sql_insert, content);

            Console.WriteLine($"test_del：删除了{result}条数据！");
        }
    }
}
