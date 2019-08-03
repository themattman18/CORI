var gulp = require('gulp');

const paths = {
    nodeModules: './node_modules/',
    scriptsDest: './Scripts/',
    stylesDest: './Content/',
    frameworksDest: './wwwroot/lib/font-awesome/'
};


gulp.task('copy:font-awesome', () => {
    const cssToCopy = [
        `${paths.nodeModules}@fortawesome/fontawesome-free/**/*`
    ];

    return gulp.src(cssToCopy)
        .pipe(gulp.dest(`${paths.frameworksDest}`));
});


gulp.task('default', gulp.series('copy:font-awesome'));