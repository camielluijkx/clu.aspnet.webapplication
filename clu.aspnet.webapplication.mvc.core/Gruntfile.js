module.exports = function (grunt) {
    grunt.initConfig({
        sass: {
            dist: {
                files: [{
                    expand: true,
                    cwd: 'Styles',
                    src: ['**/*.scss'],
                    dest: 'wwwroot/styles',
                    ext: '.css'
                }]
            }
        }
    });

    grunt.loadNpmTasks("grunt-sass");
};