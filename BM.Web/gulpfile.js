/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

const gulp = require('gulp');
const concat = require('gulp-concat');
const browserify = require('browserify');
const reactify = require('reactify');
const source = require('vinyl-source-stream');
const buffer = require('vinyl-source-buffer');
const rename = require('gulp-rename');
const minify = require('gulp-uglify');

const config = {
    paths: {
        mainJsx: './WorkFiles/Src/main.jsx',
        dist: './WorkFiles/Prod'
    }
}

gulp.task('jsx', function () {
    browserify(config.paths.mainJsx)
    .transform(reactify)
    .bundle()
    .pipe(buffer('fat.js'))
    .pipe(rename('fat-min.js'))
    .pipe(minify())
    .pipe(gulp.dest(config.paths.dist + '/js/compiled'))
})

gulp.task('default', function () {
    // place code for your default task here
});