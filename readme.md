# instalaciones nesesarias

git init

git lfs install

# configuracion del track

git lfs track "*.fbx"

git lfs track "*.blend"

git lfs track "*.png"
git lfs track "*.jpg"
git lfs track "*.psd"
git lfs track "*.wav"
git lfs track "*.mp4"

# se confirma 

git lfs track

# se agrega todo corectamente 

git add .

git status

# agregar todo corectamente

git add .

git status

git commit -m "Initial Unity project commit"

# Conectar y subir

git branch -M main
git remote add origin https://github.com/NIKO-WAFLLE/TEST-MASMORA-VR.git
git push -u origin main

# para subir cambios 

git add Assets ProjectSettings Packages
git commit -m "mensaje claro"
git push -u origin main

o

git add .
git commit -m "Test actualizar readme"
git push -u origin main

# para descargar cambios 

git pull
