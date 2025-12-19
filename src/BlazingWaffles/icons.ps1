magick convert -background none -define icon:auto-resize="32,16" wwwroot\favicon.svg wwwroot\favicon.ico
magick mogrify -trim wwwroot\favicon.ico

magick convert -background none -resize 192x192 wwwroot\favicon.svg wwwroot\favicon-192.png
magick mogrify -trim wwwroot\favicon-192.png