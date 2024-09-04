using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controller
{
    [Route("[controller]")]
    public class CarrosController : Controller
    {


        app.get("/", async(req, res) => {
        let connection;
            try {
                    const connection = await db;
                     connection.query();
            } 
            catch (err) {
                throw new Error(err);
            } finally {
            connection.close();
            }
        });


        //GetAll Carros
            app.get("/Carros", async (req, res) =>
            {
            let connection;
                try
                {
                    connection = await db.connect();
                    const request = db.request();
                    const results = await request.query("SELECT * FROM carro;");
                    res.status(200).json(results);
                 }
                catch (err)
                 {
                    res.status(500).json({ err });
                    } finally {
                    connection.close();
                }
                });

        //Post Carros
            app.post("/Carros", async (req, res) =>
            {
            let connection;
                try
                {
                    connection = await db.connect();
                    const request = db.request();
                    console.log(req.body);
                    const results = await request.query(`INSERT INTO carro

                    VALUES( 
                    ${ req.body.cor_id}, '${req.body.nome}', '${req.body.marca}',
                    ${ req.body.ano}, ${ req.body.quantidade_de_portas});`);

                    res.status(201).json(results);
                     console.log("Carro criado!");
                }
                catch (err) {
                    res.status(500).json({ err });
                    }finally {
                connection.close();
                }
            });
    }
}