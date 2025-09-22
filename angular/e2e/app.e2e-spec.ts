import { myprojTemplatePage } from './app.po';

describe('myproj App', function() {
  let page: myprojTemplatePage;

  beforeEach(() => {
    page = new myprojTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
