var gulp = require('gulp');
var sass = require('gulp-sass');
var concat = require("gulp-concat");
var cssmin = require("gulp-cssmin");
var uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/",
    nodeModules: "./node_modules/"
};

paths.sass = "./Styles/*.scss";
paths.compiledCss = paths.webroot + "styles/";
paths.bootstrapCss = paths.nodeModules + "bootstrap/dist/css/bootstrap.css";
paths.vendorCssFileName = "vendor.min.css";
paths.destinationCssFolder = paths.webroot + "styles/";
paths.sassFiles = "./Styles/*.scss";
paths.compiledCssFileName = "style.min.css";
paths.destinationCssFolder = paths.webroot + "styles/";
paths.bootstrapjs = paths.nodeModules + "bootstrap/dist/js/bootstrap.js";
paths.jqueryjs = paths.nodeModules + "jquery/dist/jquery.js";
paths.vendorJsFiles = [paths.bootstrapjs, paths.jqueryjs];
paths.vendorJsFileName = "vendor.min.js";
paths.destinationJsFolder = paths.webroot + "scripts/";
paths.jsFiles = "./Scripts/*.js";
paths.minifiedJsFileName = "scripts.min.js";

gulp.task("sass", function () {
    return gulp.src(paths.sass)
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(paths.compiledCss));
});

gulp.task("minify-vendor-css", function () {
    return gulp.src(paths.bootstrapCss)
        .pipe(concat(paths.vendorCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

gulp.task("minify-sass", function () {
    return gulp.src(paths.sassFiles)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat(paths.compiledCssFileName))
        .pipe(cssmin())
        .pipe(gulp.dest(paths.destinationCssFolder));
});

gulp.task("minify-vendor-js", function () {
    return gulp.src(paths.vendorJsFiles)
        .pipe(concat(paths.vendorJsFileName))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destinationJsFolder));
});

gulp.task("minify-js", function () {
    return gulp.src(paths.jsFiles)
        .pipe(concat(paths.minifiedJsFileName))
        .pipe(uglify())
        .pipe(gulp.dest(paths.destinationJsFolder));
});