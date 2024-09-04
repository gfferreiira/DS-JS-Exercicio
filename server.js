import express from "express";
import db from "./DataContext/database.js";

const app = express();

app.use(express.json());
app.use(express.urlencoded({ extended: true, limit: "500kb" }));


app.listen(3000);
