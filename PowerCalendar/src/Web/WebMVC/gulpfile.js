/// <binding BeforeBuild='default' />
// 'use strict';

// var path = require('path');
// var gulp = require('gulp');
// var less = require('gulp-less');
// var clean = require('gulp-clean');
// var minifycss = require('gulp-minify-css');

// //CONFIG PATHS
// var config = {
// 	pages: './pages',
// 	assets: './assets',
// 	build: './dist'
// };

// //TASKS
// gulp.task('less', function () {
// 	gulp.src(config.pages + '/less/pages.less')
// 		.pipe(less({
// 			paths: [config.pages + '/less/']
// 		}))
// 		.pipe(gulp.dest(config.pages + '/css/'));
// });
// gulp.task('watch', function () {
// 	gulp.watch(config.pages + '/less/*.less', function (event) {
// 		gulp.run('less');
// 	});
// });

// gulp.task('build', ['less', 'copy'], function () {
// 	gulp.run('css-min');

// });

// gulp.task('clean', function () {
// 	return gulp.src(config.build + '', { read: false })
// 		.pipe(clean());
// });

// gulp.task('copy', ['clean'], function () {
// 	return gulp.src(['./**/*', '!**/node_modules/**', '!.gitgnore', '!package.json', '!Gruntfile.js', '!gulpfile.js'])
// 		.pipe(gulp.dest(config.build + ''));
// });

// gulp.task('css-min', function () {
// 	return gulp.src([config.build + './assets/css/*.css', config.build + './pages/css/*.css'])
// 		.pipe(minifycss());
// });

// gulp.task('default', function () {
// 	console.log("\nPage - Gulp Command List \n");
// 	console.log("----------------------------\n");
// 	console.log("gulp watch");
// 	console.log("gulp less");
// 	console.log("gulp build \n");
// 	console.log("----------------------------\n");
// });

const { src, dest, series } = require('gulp');
var clean = require('gulp-clean');

function clear(cb) {
	src('wwwroot/js/bootstrap/*.js')
		.pipe(clean());
	src('wwwroot/css/bootstrap/*.css')
		.pipe(clean());
	src('wwwroot/js/select2/*.css')
		.pipe(clean());
	src('wwwroot/css/select2/*.css')
		.pipe(clean());
	src('wwwroot/js/jquery/*.js')
		.pipe(clean());
	src('wwwroot/js/popper/*.js')
		.pipe(clean());
	src('wwwroot/js/jquery-unveil/*.js')
		.pipe(clean());
	src('wwwroot/js/classie/*.js')
		.pipe(clean());
	src('wwwroot/js/jquery-validation/*.js')
		.pipe(clean());
	cb();
}

function alljs(cb) {
	src('node_modules/bootstrap/dist/js/bootstrap.min.js')
		.pipe(dest('wwwroot/js/bootstrap/'));
	src('node_modules/bootstrap/dist/css/bootstrap.min.css')
		.pipe(dest('wwwroot/css/bootstrap/'));
	src('node_modules/bootstrap/dist/css/bootstrap.min.css.map')
		.pipe(dest('wwwroot/css/bootstrap/'));
	src('node_modules/select2/dist/js/*.js')
		.pipe(dest('wwwroot/js/select2/'));
	src('node_modules/select2/dist/css/*.css')
		.pipe(dest('wwwroot/css/select2/'));
	src('node_modules/jquery/dist/*.js')
		.pipe(dest('wwwroot/js/jquery/'));
	src('node_modules/@popperjs/core/dist/umd/*.js')
		.pipe(dest('wwwroot/js/popper/'));
	src('node_modules/jquery-unveil/*.js')
		.pipe(dest('wwwroot/js/jquery-unveil/'));
	src('node_modules/classie/lib/*.js')
		.pipe(dest('wwwroot/js/classie/'));
	src('node_modules/jquery-validation/dist/*.js')
		.pipe(dest('wwwroot/js/jquery-validation/'));
	src('node_modules/feather-icons/dist/**/*')
		.pipe(dest('wwwroot/js/feather-icons/'));
	src('node_modules/moment/dist/**/*')
		.pipe(dest('wwwroot/js/moment/'));
	src('node_modules/interactjs/dist/*.js')
		.pipe(dest('wwwroot/js/interactjs/'));
	cb();
}

exports.default = series(clear, alljs);

