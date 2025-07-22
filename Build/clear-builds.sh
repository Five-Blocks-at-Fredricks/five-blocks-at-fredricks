rm -rf Build/linux/*
rm -rf Build/windows/*
rm -rf Build/mac/*
rm -rf Build/linux-arm/*

touch Build/linux/.gitkeep
touch Build/windows/.gitkeep
touch Build/mac/.gitkeep
touch Build/linux-arm/.gitkeep

rm -rf Build/fbaf-linux-arm.zip
rm -rf Build/fbaf-linux.zip
rm -rf Build/fbaf-windows.zip
rm -rf Build/fbaf-mac.zip