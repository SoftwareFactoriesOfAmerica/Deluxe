===== Common Git commands =====

	VS Code:	https://code.visualstudio.com/Docs/editor/versioncontrol
	git: 		https://stackoverflow.com/questions/572549/difference-between-git-add-a-and-git-add
	

Amelio-React VS Code Project file:
================================================
	Azure DevOps:
	https://jta-bi.visualstudio.com/Amelio-react/_git/Amelio-React
		
===== React in VS Code Terminal =====

Running locally:

	npm install -D (just once to install all the packages)
	npm start

Running Production

	npm run-script build (this is for production)

Stopping:

	[Ctrl]+{C] -- stops the terminal


Saving:

	use the menu item File --> SaveAll -- typically used when is it running or not running

===== Installations =====

	npm i webpack -S
	npm audit fix
		
	npm i --save @fortawesome/fontawesome
	npm i --save @fortawesome/react-fontawesome
	npm i --save @fortawesome/fontawesome-free-solid

	npm install --save-dev json-loader

  npm install --save redux react-redux
	npm install react-bootstrap-table --save
	npm install react-bootstrap-dropdown --save
	npm i -S reactstrap
	npm i query-string
	npm install jquery --save
	npm install react-modal-dialog --save
	npm install validator --save
	npm i --save lodash

	npm install --no-fund core-js
	
===== Git add project to git local =====
git update-git-for-windows

	cd "path to your repo"
	git init
	git add . # if you want to commit everything. Otherwise use .gitconfig files
	git commit -m "initial commit" # If you change anything, you can add and commit again...

===== Git add git local to remote =====

	git remote add origin https://jta-bi.visualstudio.com/_git/Amelio-React
	git remote show origin # if everything is ok, you will see your remote
	git push -u origin master # assuming your are on the master branch.

===== VS Code =====
	
	It is now possible to set the origin from VS Code "WITHOUT" command line typing:
	git remote add origin https://github.com/USR/REPO.git

	From within VS Code you may CTRL+SHIFT+P if you are on Windows and type remote.
	From there select Git: Add Remote and you will have two steps:
		Set origin for the remote name:
		Add origin URL: https://jta-bi.visualstudio.com/_git/Amelio-React

===== git remove and change remote =====

	git remote -v
	git remote set-url origin https://jta-bi.visualstudio.com/_git/Amelio-React
	git remove -v


===== Update DBContext =====

	NOTE: "Microsoft.EntityFrameworkCore.SqlServer; Microsoft.EntityFrameworkCore.Design; Microsoft.EntityFrameworkCore.Tools and Microsoft.EntityFrameworkCore.Relational" must be installed in the Amelio-Service Project.

	open Package Manager Console and enter the following:

	PM> Scaffold-DbContext "Server=localhost;Database=Amelio;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Models
	
===== git commands when updating change(s) =====
-- be sure that a gitignore is in place
git add .
git commit -m " <commit message>"
git push origin <branch>

===== git common commands =====
git branch
git branch testing		Creating a New Branch called testing

git branch -D <local branch name>
git list branches

git checkout <branch name>

git checkout -b <branch name>

git commit -m <commit message>
git commit --amend -m <new commit message>

git diff

git help -a

git init

git log

git merge <branch>

git mv <oldfilename> <newfilename>

git pull

git reset --hard

git stash

git status

===== git pull request (PR) =====
git request-pull --help


git checkout -b <branch-name>
git request-pull master ./

