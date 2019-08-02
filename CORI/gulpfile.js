var gulp = require('gulp');

const paths = {
    nodeModules: './node_modules/',
    scriptsDest: './Scripts/',
    stylesDest: './Content/',
    frameworksDest: './wwwroot/css/'
};


gulp.task('copy:font-awesome', () => {
    const cssToCopy = [
        `${paths.nodeModules}font-awesome/css/font-awesome.min.css`
    ];

    return gulp.src(cssToCopy)
        .pipe(gulp.dest(`${paths.frameworksDest}`));
});


gulp.task('default', gulp.series('copy:font-awesome'));