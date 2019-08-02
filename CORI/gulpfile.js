var gulp = require('gulp');

const paths = {
    nodeModules: './node_modules/',
    scriptsDest: './Scripts/',
    stylesDest: './Content/',
    frameworksDest: './wwwroot/lib/font-awesome/'
};


gulp.task('copy:font-awesome:css', () => {
    const cssToCopy = [
        `${paths.nodeModules}@fortawesome/fontawesome-free/css/fontawesome.min.css`
    ];

    return gulp.src(cssToCopy)
        .pipe(gulp.dest(`${paths.frameworksDest}css`));
});

gulp.task('copy:font-awesome:fonts', () => {
    const cssToCopy = [
        `${paths.nodeModules}@fortawesome/fontawesome-free/webfonts/*`
    ];

    return gulp.src(cssToCopy)
        .pipe(gulp.dest(`${paths.frameworksDest}webfonts`));
});


gulp.task('default', gulp.series('copy:font-awesome:css', 'copy:font-awesome:fonts'));