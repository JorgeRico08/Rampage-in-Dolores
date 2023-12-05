const express = require('express');
const https = require('https');
const fs = require('fs');

const app = express();

// Aquí le decimos a Express que sirva archivos estáticos desde la carpeta actual
app.use(express.static('.'));

const options = {
    key: fs.readFileSync(__dirname + '/private-key.pem'),
    cert: fs.readFileSync(__dirname + '/certificate.pem')
};

const puerto = 3000;

const server = https.createServer(options, app);

server.listen(puerto, () => {
  console.log(`Servidor HTTPS de Express escuchando en el puerto ${puerto}`);
});