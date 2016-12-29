var webpack = require('webpack');
var path = require('path');

module.exports = {
    entry: {
        filename: './WorkFiles/Source/index.tsx'
    },
    output: {
        path: path.join(__dirname, '/WorkFiles/Prod'),
        filename: 'fat.js'
    },
    resolve: {
        extensions: ["", ".webpack.js", ".web.js", ".ts", ".tsx", ".js"]
    },
    plugins: [
      new webpack.ProvidePlugin({
          'fetch': 'imports?this=>global!exports?global.fetch!whatwg-fetch'
      })
    ],
    module: {
        loaders: [
            {
                test: /\.tsx?$/,
                exclude: /(node_modules|bower_components)/,
                loader: 'ts-loader'
            }
        ],
        preLoaders: [
            {
                test: /\.js$/,
                loader: "source-map-loader"
            }
        ]
    },
    externals: {
        "react": "React",
        "react-dom": "ReactDOM"
    }
};
