/// <binding Clean='clean' />

var gulp = require("gulp"),
  rimraf = require("rimraf"),
    glob = require("glob"),
    path = require("path"),
  fs = require("fs");

var paths = {
    bower: "./bower_components/",
    vendors: "./" + "Libs/"
};

gulp.task("clean", function (cb) {
    rimraf(paths.vendors, cb);
});

gulp.task("copy", ["clean"], function () {
    var bowerStrict = {
   
        "angular": "angular/*.{css,js,map}",
        "angular-route": "angular-route/*.{css,js,map}",
        "angular-resource": "angular-resource/*.{css,js,map}",
        "angular-odata-resources": "angular-odata-resources/build/odataresources.min.js",
       
        "todomvc-common": "todomvc-common/*.{css,js}",
    }// "todomvc-app-css": "todomvc-app-css/*.{css,js}",



    for (var destinationDir in bowerStrict) {
  
        console.log(destinationDir);
        gulp.src(paths.bower + bowerStrict[destinationDir])
          .pipe(gulp.dest(paths.vendors + destinationDir));
    }

 

});

function getDirectories(srcpath) {
    return fs.readdirSync(srcpath).filter(function (file) {
        return fs.statSync(path.join(srcpath, file)).isDirectory();
    });
}
