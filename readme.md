# Probar trabajar proyectos con github entre varios dispositivos y la configuracion local 

Este es un proyecto muy especial para mí. Fue desarrollado en una laptop HP Victus 15 con los ventiladores rotos, lo que provocaba que se apagara por sobrecalentamiento cada 10 o 20 minutos. Debido a esto, el desarrollo me tomó más de dos meses (para una materia de mi universidad), ya que no podía realizar muchas pruebas sin que el equipo colapsara a mitad de una.

Le terminé tomando mucho cariño a este trabajo y decidí subirlo aquí para respaldarlo y, de paso, aprender a usar GitHub con Unity. Fue realizado directamente en Git Bash porque no me acostumbro a al control de versiones de unity (no supe configurarlo creo).

Lo dejo público por si la configuración de GitHub le resulta útil a alguien, aunque honestamente dudo que alguien llegue a leer esto.

- nota: Escrito el sábado 14 de febrero de 2025 a la 1:09 AM.
 
## version ocupada 2022.3.62f1
## Modulos OpenJDK y Android SDK & NDK Tools

# Clonar repositorio 

### clonar en un nuevo repositorio 

git lfs install

git clone https://github.com/NIKO-WAFLLE/TEST-MASMORA-VR.git

cd TEST-MASMORA-VR

git lfs pull

# pasos para crear tu repositorio 

### Instalaciones nesesarias

git init

git lfs install

### configuracion del track

git lfs track "*.fbx"

git lfs track "*.blend"

git lfs track "*.png"

git lfs track "*.jpg"

git lfs track "*.psd"

git lfs track "*.wav"

git lfs track "*.mp4"

## se confirma 

git lfs track

## se agrega todo corectamente 

git add .

git status

## agregar todo corectamente

git add .

git status

git commit -m "Initial Unity project commit"

## Conectar y subir

git branch -M main
git remote add origin https://github.com/NIKO-WAFLLE/TEST-MASMORA-VR.git
git push -u origin main

## para subir cambios 

git add Assets ProjectSettings Packages
git commit -m "mensaje claro"
git push -u origin main

o

git add .
git commit -m "Test actualizar readme"
git push -u origin main

## para descargar cambios 

git pull
git lfs pull

# IMPORTANTE GITIGNORE 

# descarga el de mi proyecto o crea uno que contenga esto 

'# Unity folders
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Uu]ser[Ss]ettings/

# OS / IDE
.DS_Store
Thumbs.db
.vscode/
.idea/
*.csproj
*.sln
*.user
*.unityproj
*.booproj

# Unity crashes
sysinfo.txt

# Builds / APKs
*.apk
*.aab
Builds/
Build/
'
## segun chat gpt puedes crearlo de forma automatica en el git bash asi - no lo probe pero sabia que se podia hacer y lo agrege xd 

'cat > .gitignore << 'EOF'
# Unity folders
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Uu]ser[Ss]ettings/

# OS / IDE
.DS_Store
Thumbs.db
.vscode/
.idea/
*.csproj
*.sln
*.user
*.unityproj
*.booproj

# Unity crashes
sysinfo.txt

# Builds / APKs
*.apk
*.aab
Builds/
Build/
EOF
'
